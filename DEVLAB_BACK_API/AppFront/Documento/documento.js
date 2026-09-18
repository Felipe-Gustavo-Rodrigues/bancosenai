const URLApi = "http://localhost:5139/api/v1/Document"

async function uploadDados() {
    const inputCodigo = document.getElementById("codigoCliente");
    const codigo = inputCodigo.value;
    const inputFile = document.getElementById("arquivoCliente");
    const arquivo = inputFile.files[0]


    if (!codigo || !arquivo) {
        alert("Codigo do cliente vazio ou sem documento");
        return;
    }
    const dadosArquivos = new FormData();
    dadosArquivos.append('arquivo', arquivo);

    const response = await fetch(`${URLApi}/upload/${codigo}`, {
        method: "POST",
        body: dadosArquivos
    });

    if (response.ok) {
        alert("Documento criado com sucessso");
        inputCodigo.value = "";
        inputFile.value = "";
    } else {
        const erro = await response.text();
        console.log(erro)
        alert(`Erro ao criar documento: ${erro}`);
    }
}

async function pesquisarCliente() {

}