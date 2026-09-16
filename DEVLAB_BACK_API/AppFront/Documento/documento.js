const URLApi = "http://localhost:5139/api/v1/Document"

async function uploadDados() {
    const inputCodigo = document.getElementById("codigoCliente");
    const codigo = inputCodigo.value;
    const inputFile = document.getElementById("arquivoCliente");
    const arquivo = inputFile.files[0]


    if (!codigo || !arquivo) {
        alert("Codigo do cliente vazio");
        return;
    }
    const dadosArquivos = new FormData();
    dadosArquivos.append('arquivo', arquivo);

    const response = await fetch(`${URLApi}/upload/${codigo}`, {
        method: "POST",
        body: dadosArquivos
    });

    if (!response.ok) {
        const erro = await response.json();
        console.log(erro)
        alert(`Erro ao criar documento: ${erro.messsage}`);
    }
    alert("Documento criado com sucessso");
    inputCodigo.value = "";
    inputFile.value = "";
}

async function pesquisarCliente() {

}