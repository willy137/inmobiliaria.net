function cambiaId(){
    let selec=document.querySelector("#idinqui").value;
    document.querySelector("#InquiId").value=selec;
}

function cambiaIdInmu(){
    let selec=document.querySelector("#idnmu").value;
    document.querySelector("#InmuId").value=selec;
}
window.onload=cambiaId(),cambiaIdInmu();

