import { useState, useEffect } from "react";
import style from "./perfil.module.scss";
import iconeMoeda from "../../assets/img/moeda.png";
import imgPerfil from "../../assets/img/usuario.jpg";
import Estatistica from "./estatistica";

export default function Profile() {
  const [dadosUsuario, setUsuario] = useState();

  useEffect(() => {
    async function getUsuario() {
      const responseProj = await fetch(
        "https://plataformaeducacional.azurewebsites.net/api/Usuario/1"
      );
      const repos = await responseProj.json();

      setUsuario(repos);
    }

    getUsuario();
  }, []);

  const dados_usuario = {
    nome: "Nome do Usuário",
    foto: `a`,
    seguidores: 3,
    seguindo: 20,
    coins: 200,
    usuarioPontuacao: 1000,
  };

  return (
    <div className={style.pagina}>
      <div className={style.perfil}>
        <div className={style.container}>
          <div className={style.coluna1}>
            <img src={imgPerfil}></img>
            <p>Crie seu avatar!</p>
          </div>
          <div className={style.coluna2}>
            <p className={style.pontuacao}>
              Pontuação <span>{dados_usuario.usuarioPontuacao}</span>
            </p>
            <p>{dados_usuario.nomeUsuario}</p>
            <p className={style.seguidores}>
              Seguidores: {dados_usuario.seguidores}
            </p>
            <p className={style.seguidores}>
              Seguindo: {dados_usuario.seguindo}
            </p>
          </div>
        </div>
        <div className={style.carteira}>
          <span>{dados_usuario.coins}</span>
          <img src={iconeMoeda}></img>
        </div>
      </div>
      <Estatistica />
    </div>
  );
}
