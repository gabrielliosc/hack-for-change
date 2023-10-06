import style from "../trilha.module.scss";
import starImg from "../../../assets/img/svg/star.svg";
import { Link } from "react-router-dom";
import { useState, useEffect } from "react";

export default function Estrela(mapa) {


  const [fases, setFases] = useState();

  useEffect(() => {
    async function getFases(mapa) {
      const responseProj = await fetch(
        "https://plataformaeducacional.azurewebsites.net/api/Fase"
      );
      const repos = await responseProj.json();
      const fasesMapa = await repos.filter(obj => { return obj.idMapa == 1  }) /

      setFases(fasesMapa);
    }

    getFases();
  }, [mapa]);

  const fases_ = [
    {
      nome: "Questao_1",
    },
    {
      nome: "Questao_2",
    },
    {
      nome: "Questao_3",
    },
    {
      nome: "Questao_4",
    },
    {
      nome: "Questao_5",
    },
    {
      nome: "Questao_6",
    },
    {
      nome: "Questao_7",
    },
    {
      nome: "Questao_8",
    },
  ];

  return (
    <div className={style.trilha}>
      {fases_.map((fase, index) => (
        <div key={index}>
          <Link to={`/fase/${fase.nome}`}>
            <img src={starImg} className=""></img>
          </Link>
        </div>
      ))}
    </div>
  );
}
