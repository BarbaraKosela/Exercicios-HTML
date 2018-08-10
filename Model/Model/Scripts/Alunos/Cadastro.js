function apagarElemento(id) {
    if (document.contains(document.getElementById(id))) {
        document.getElementById(id).remove();
    }
}

function ValidarFormulario() {
    var textoCampoMatricula = document.getElementById("campo-matricula").value;
    var textoCampoNota01 = document.getElementById("campo-nota01").value;
    var textoCampoNota02 = document.getElementById("campo-nota02").value;
    var textoCampoNota03 = document.getElementById("campo-nota03").value;
    var textoCampoFrequencia = document.getElementById("campo-frequencia").value;
    var textoCampoFaltas = document.getElementById("campo-faltas").value;
    if (ValidarCampoNome() == false) {
        event.preventDefault();
    }
}

function ValidarCampoNome() {
    var textoCampoNome = document.getElementById("campo-nome").value;

    
    apagarElemento("span-campo-nome-menor-10");
    apagarElemento("span-campo-nome-maior-100")

    if (textoCampoNome.lenght < 10) {
        var elementoSpanNome = document.createElement("span");
        elementoSpanNome.textContent = "Nome deve conter no mínimo 10 caracteres";
        elementoSpanNome.id = "span-campo-nome-menor-10";

        elementoSpanNome.classList.add("text-danger");
        document.getElementById("div-campo-nome").appendChild(elementoSpanNome);
        document.getElementById("campo-nome").classList.add("border-danger");
        return false;

    }

    if (textoCampoNome.lenght > 100) {
        var elementoSpanNome = document.createElement("span");
        elementoSpanNome.textContent = "Nome deve conter no máximo 100 caracteres";
        elementoSpanNome.id = "span-campo-nome-maior-100";
        elementoSpanNome.classList.add("text-danger");
        document.getElementById("campo-nome").appendChild(elementoSpanNome);
        document.getElementById("campo-nome").classList.add("border-danger");
        return false;
    }

    if (textoCampoNome.lenght < 7 && textoCampoNome.lenght <= 100) {
        document.getElementById("campo-nome").classList.remove("border-danger");
        document.getElementById("campo-nome").classList.add("border-sucess");
        
    }
}

