

let i = 0

const BtnInserir = document.getElementById("Btn_Inserir")
const Compras = document.getElementById("Compras")
const Tarefas = document.getElementById("Tarefas")
const Texto = document.getElementById("TxtTexto")

BtnInserir.addEventListener("click", SetText)

document.addEventListener('keypress', function (event) {
    if (event.key === 'Enter') {
        SetText();
    }
});

function SetText() {
    const idLi = "Li_" + i;
    const li = document.createElement("li")
    const btnRemove = document.createElement("button")
    btnRemove.innerText = "Excluir"
    btnRemove.className = "btnRemove"
    li.id = idLi
    //function()
    const RemoverLi = () => {
        document.getElementById(idLi).remove()
    }
    btnRemove.addEventListener("click", RemoverLi)
    li.innerText = Texto.value
    li.appendChild(btnRemove)
    console.log()
    if (document.getElementById("TxtTexto").value == "") {
        return alert("Campo de texto está vázio.")
    }
    if (document.getElementById("radioCompras").checked == "" && document.getElementById("radioTarefas").checked == "") {
        return alert("É necessário selecionar um dos seletores abaixo.")
    }
    if (document.getElementById("radioCompras").checked) {
        Compras.appendChild(li)
    }
    if (document.getElementById("radioTarefas").checked) {
        Tarefas.appendChild(li)
    }
    i++
}

function OpenPag(pId) {
    window.location.href = `/?IdEquipe=${pId}`
    // Seleciona o primeiro elemento com a classe .containerPanel
    const containerPanel = document.querySelector('.containerPanel');

}

