import style from "./estatistica.module.scss";
import { useState, useEffect } from "react";

export default function Estatistica() {

  const [usuarioMapa, setDadosMapa] = useState();

  useEffect(() => {

    async function getdadosMapa() {
      const responseProj = await fetch(
        "https://plataformaeducacional.azurewebsites.net/api/Usuario/1"
      );
      const repos = await responseProj.json();

      setDadosMapa(repos);
    }

    getdadosMapa();
  }, []);

  const dados_usuario = [
    {
      nome: "Nome do Usuário",
      pontucao: 430,
      materia: "Matemática",
      mapaAtual: "Soma",
    },
    {
      nome: "Nome do Usuário",
      pontucao: 570,
      materia: "Portugues",
      mapaAtual: "Redação",
    },
  ];

  return (
    <div className={style.container}>
      <h3>Estatística das Matérias</h3>
      <div className={style.estatistica}>
        {dados_usuario.map((dado, index) => (
          <div key={index}>
            <h4>{dado.materia}</h4>
            <p>Pontuação total: {dado.pontucao}</p>
            <p>Mapa Atual: {dado.mapaAtual}</p>
          </div>
        ))}
      </div>
    </div>
  );
}
