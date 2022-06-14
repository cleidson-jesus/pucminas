export const dateFields = ["dataHoraInclusao", "dataNascimento", "dataHoraAtualizacao", "dataFichaCadastral"];

export const selectOptions = {
    selectInputOptions: [
        { name: "Masculino", value: "M" },
        { name: "Feminino", value: "F" },
        { name: "Não informado", value: "N/I" },
    ],
    trueOrFalseOptions: [
        { name: "Sim", value: true },
        { name: "Não", value: false }
    ],
    generoOptions: [
        { name: "Masculino", value: 1 },
        { name: "Feminino", value: 2 },
        { name: "Outro", value: 3 }
    ],
    tipoOptions: [
        { name: "Pessoa Física", value: 1 },
        { name: "Pessoa Jurídica", value: 2 }
    ],
    ratingOptions: [
        { name: "A", value: 1 },
        { name: "B", value: 2 }
    ],
    cidadeNascimentoOptions: [
        { name: "Belo Horizonte", value: 1 }
    ]
}