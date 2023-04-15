function cambioId(){
    let selec=document.querySelector("#selecIdInmu").value;
    document.querySelector("#InmuId").value=selec;
}
function cambioIdInqui(){
    let selec=document.querySelector("#selecIdInqui").value;
    document.querySelector("#InquiId").value=selec;
}
function cambioSelec(){
    let idinmu=document.querySelector("#InmuId").value;
    document.querySelector("#selecIdInmu").value=idinmu;
    let inqui=document.querySelector("#InquiId").value;
    document.querySelector("#selecIdInqui").value=inqui;
}
window.onload=cambioSelec();