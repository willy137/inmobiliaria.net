using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Claims;

namespace mvc.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IConfiguration configuracion;

        private readonly IWebHostEnvironment environment1;

        private readonly IRepositorioUsuario repoU;


        public UsuariosController(IConfiguration configuration, IWebHostEnvironment environment,IRepositorioUsuario repo){
            this.configuracion=configuration;
            this.environment1=environment;
            this.repoU=repo;
        }




        // GET: Usuarios
        [Authorize(Policy = "Administrador")]
        public ActionResult Index()
        {
           try{
                var claims =User.Claims;
                string Rol = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                ViewBag.Rol=Rol;
                IList<Usuario> users=repoU.GetObtenerTodos();
                return View(users);
           }catch(Exception ex){
                throw;
           }
        }
        [Authorize]
        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [Authorize]
        // GET: Usuarios/Create
        public ActionResult Create()
        {
            try{
                return View();
            }catch(Exception ex){
                throw;
            }

        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                    string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                                    password: usuario.Password,
                                    salt: System.Text.Encoding.ASCII.GetBytes(configuracion["Salt"]),
                                    prf: KeyDerivationPrf.HMACSHA256,
                                    iterationCount: 1000,
                                    numBytesRequested: 256 / 8));
                    usuario.Password = hashed;
                    var nbreRnd = Guid.NewGuid();
                    if (usuario.ImgAvatar != null){
                        string wwwPath = environment1.WebRootPath;
                        string path = Path.Combine(wwwPath, "Uploads");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        string fileName = "avatar_" + nbreRnd + Path.GetExtension(usuario.ImgAvatar.FileName);
                        string pathCompleto = Path.Combine(path, fileName);
                        usuario.Avatar = Path.Combine("/Uploads", fileName);
                        using (FileStream stream = new FileStream(pathCompleto, FileMode.Create))
                        {
                            usuario.ImgAvatar.CopyTo(stream);
                        }
			        }
                    int res = repoU.Create(usuario);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        [Authorize]
        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            try{
                if(id==null || id==0){
                    var claims =User.Claims;
                    string correo = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
                    Usuario user1=repoU.ObtenerCorreo(correo);
                    return View(user1);
                }
                Usuario user=repoU.Obtener(id);
                return View(user);
            }catch(Exception ex){
                throw;
            }

        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Policy = "Administrador")]
        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [AllowAnonymous]
		// GET: Usuarios/Login/
		public ActionResult Login(string returnUrl)
		{
			TempData["returnUrl"] = returnUrl;
			return View();
		}

		// POST: Usuarios/Login/
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(Usuario user)
		{
			try
			{
				var volverUrl = String.IsNullOrEmpty(TempData["returnUrl"] as string) ? "/Home" : TempData["returnUrl"].ToString();
				if (ModelState.IsValid)
				{
					string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
						password: user.Password,
						salt: System.Text.Encoding.ASCII.GetBytes(configuracion["Salt"]),
						prf: KeyDerivationPrf.HMACSHA256,
						iterationCount: 1000,
						numBytesRequested: 256 / 8));
					var usuario = repoU.ObtenerCorreo(user.Correo);
					if (usuario == null || usuario.Password != hashed)
					{
						ModelState.AddModelError("", "El Correo o la clave son Incorrectos");
						TempData["returnUrl"] = volverUrl;
						return View();
					}

					var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, usuario.Correo),
                        new Claim("FullName", usuario.Nombre + " " + usuario.Apellido),
                        new Claim(ClaimTypes.Role, usuario.RolNombre),
                        new Claim(ClaimTypes.NameIdentifier, usuario.UsuarioId+""),
                    };

					var claimsIdentity = new ClaimsIdentity(
							claims, CookieAuthenticationDefaults.AuthenticationScheme);

					await HttpContext.SignInAsync(
							CookieAuthenticationDefaults.AuthenticationScheme,
							new ClaimsPrincipal(claimsIdentity));
					TempData.Remove("returnUrl");
					return Redirect(volverUrl);
				}
				TempData["returnUrl"] = volverUrl;
				return View();
			}
			catch (Exception ex)
			{
                throw;
            }
		}

        public async Task<ActionResult> Logout()
		{
			await HttpContext.SignOutAsync(
					CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index", "Home");
		}

    }
}