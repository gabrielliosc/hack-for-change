import starImg from "../../assets/img/svg/star.svg";
import Estrela from "./estrela";
import style from "./trilha.module.scss";
import { useState, useEffect } from "react";

export default function Trilha() {
  const mapa = "Soma";
  const [mapaTrilha, setMapa] = useState();

  useEffect(() => {
    async function getMapa() {
      const responseProj = await fetch(
        "https://plataformaeducacional.azurewebsites.net/api/Usuario/1"
      );
      const repos = await responseProj.json();

      setMapa(repos);
    }

    getMapa();
  }, []);
  
  return (
    <Estrela mapa={1}/>
  );
}
