import { useEffect } from "react";

function ListarProdutos(){

    useEffect(() => {
        //AXIOS
        fetch("https://viacep.com.br/ws/83605200/json/").then(resposta => {
            return resposta.json();
        }).then(dados => {
            console.log(dados.localidade);
            console.log(dados.logradouro);
        });
    }, []);
    
    return(
        <div>
        <h1>Listar Produtos</h1>
    </div>
    );
}

export default ListarProdutos;