const URLApi = "http://localhost:5139/api/v1/Document";
async function uploadDados() {
    const inputCodigo = document.getElementById("codigoClienteD");
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
        document.getElementById("codigoClienteB").value = codigo;
        buscarDocumento();
    } else {
        const erro = await response.text();
        console.log(erro)
        alert(`Erro ao criar documento: ${erro}`);
    }
}

async function buscarDocumento() {

    const inputCodigoDocumento = document.getElementById("codigoClienteB");
    const codigo = inputCodigoDocumento.value;
    const table = document.getElementById("tableDocumentos");

    const response = await fetch(`${URLApi}/listagem/${codigo}`, {
        method: "GET"
    });

    if (!response.ok) {
        const erro = await response.text();
        console.log(erro)
        alert(`Erro ao encontrar documento do cliente: ${erro}`);
    }

    const dados = await response.json();
    table.innerHTML = "";
    dados.forEach(e => {
        let linha = document.createElement("tr");
        let id = document.createElement("td");
        let nome = document.createElement("td");
        let extensao = document.createElement("td");
        let acoes = document.createElement("td");
        let buttonExcluir = document.createElement("button");
        let buttonDowload = document.createElement("button");

        id.textContent = e.id;
        nome.textContent = e.nome;
        extensao.textContent = e.extensao;
        buttonDowload.textContent = "Dowload";
        buttonExcluir.textContent = "Excluir";
        buttonDowload.classList.add("btn-editar");
        buttonExcluir.classList.add("btn-excluir");

        buttonDowload.addEventListener('click', (e)=> {
            const nomeCompleto = `${nome.textContent}${extensao.textContent}`;
            dowloadDocumento(id.textContent, nomeCompleto, codigo);
        })
        buttonExcluir.addEventListener('click', (e) => {
            deleteDocumento(id.textContent, codigo);
        });

        acoes.append(buttonDowload, buttonExcluir);
        linha.append(id, nome, extensao, acoes);
        table.appendChild(linha);
    })
}

async function deleteDocumento(codigoDocumento, codigoCliente) {
    if (!confirm("Você vai querer mesmo apagar esse arquivo?")) {
        return;
    }
    const response = await fetch(`${URLApi}/cliente/${codigoCliente}/excluir/${codigoDocumento}`, {
        method: "DELETE"
    });
    if (response.ok) {
        alert("Documento deletado com sucessso");
    } else {
        const erro = await response.text();
        console.log(erro);
        alert(`Erro ao deletar documento: ${erro}`);
    }
    buscarDocumento();
}

async function dowloadDocumento(codigoDocumento, nomeArquivo, codigoCliente) {
    const response = await fetch(`${URLApi}/cliente/${codigoCliente}/dowload/${codigoDocumento}`, {
        method: "GET"
    });
    if (!response.ok) {
        const erro = await response.text();
        console.log(erro)
        alert(`Erro ao encontrar documento do cliente: ${erro}`);
    }

    const arquivo = await response.blob();

    const urlArquivo = URL.createObjectURL(arquivo);
    const a = document.createElement("a");
    a.href = urlArquivo;
    a.download = nomeArquivo;

    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);

    URL.revokeObjectURL(arquivo);
}