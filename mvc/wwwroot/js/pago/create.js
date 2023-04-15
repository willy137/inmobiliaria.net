function cambiaId(){
    let selec=document.querySelector("#contraId").value;
    document.querySelector("#ContratoId").value=selec;
}

function cambiaIdInqui(){
    let selec=document.querySelector("#idnmu").value;
    document.querySelector("#InmuId").value=selec;
}
window.onload=cambiaId(),cambiaIdInmu();

