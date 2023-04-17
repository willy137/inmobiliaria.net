function inicio(){
    let rol=document.querySelector("#rol").value;
    document.querySelector("select").value=rol;
}
window.onload=inicio();
function cambio(){
    let rol=document.querySelector("#select").value;
    document.querySelector("rol").value=rol;
}