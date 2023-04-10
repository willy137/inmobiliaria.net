
function buscar(){
    let lugar=document.querySelector("#buscador");
    let div=document.createElement("div");
    div.setAttribute("class","form-group");
    div.setAttribute("id","busca");
    let label=document.createElement("label");
    label.innerHTML="Nombre Propietario";
    let nom=document.createElement("input");
    nom.setAttribute("id","nombre");
    let button=document.createElement("button");
    button.setAttribute("onclick","buscarprop()");
    button.innerHTML="Buscar";
    lugar.appendChild(div);
    div.appendChild(label);
    div.appendChild(nom);
    div.appendChild(button);
    let busqueda=document.querySelector("#busqueda");
    lugar.removeChild(busqueda);
}

function redi(){
    window.location.href="http://localhost:5035/Inmuebles";
}

