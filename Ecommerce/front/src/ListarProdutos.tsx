import { useEffect, useState } from "react";

function ListarProdutos(){

    const[produtos, setProdutos] = useState([]);

    useEffect(() => {
        //AXIOS
        fetch("http://localhost:5062/api/produto/listar")
            .then(resposta => {
                return resposta.json();
            }).then(produtos => {
                setProdutos(produtos);
            });
    }, []);
    
    return(
    <div>
        <h1>Lista de Produtos</h1>
        <ul>
            {produtos.map((produto : any) => (
                <li>{produto.nome}</li>
            ))}
        </ul>
    </div>
    );
}

export default ListarProdutos;