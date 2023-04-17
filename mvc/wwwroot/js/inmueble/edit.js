var cant=0;
function cambioId(){
    if(cant==0){
        let selec=document.querySelector("#PropId").value;
        document.querySelector("#selecId").value=selec;
    }else{
        let selec=document.querySelector("#selecId").value;
        document.querySelector("#PropId").value=selec;
    }
    cant+=1;
}

window.onload=cambioId();