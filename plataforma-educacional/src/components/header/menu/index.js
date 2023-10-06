import { useState } from "react";
import style from "./menu.module.scss";
import { Link } from "react-router-dom";

export default function Menu() {
  let [active, setActive] = useState({
    show: true,
  }); //Para controlar o estilo de menu hamburguer no mobile

  const styleLine1 = `${style.line} ${style.line1}`;
  const styleLine2 = `${style.line} ${style.line2}`;
  const styleLine3 = `${style.line} ${style.line3}`;
  const styleActive = `${style.btn} ${style.active}`;

  const pages = [
    {
      nome: "Home",
      route: "/",
    },
    {
      nome: "Cadastro",
      route: "/cadastro",
    },
    {
      nome: "Quiz",
      route: "/quizForm",
    },
    {
      nome: "Login",
      route: "/login",
    },
    {
      nome: "Perfil",
      route: "/perfil"},
    // },
    // {
    //   nome: "Teste de Habilidade",
    //   route: "/teste-habilidade",
    // },
    {
      nome: "Mapa",
      route: "/mapa",
    },
  ];
  return (
    <nav>
      <div
        onClick={() => {
          setActive({ show: !active.show });
        }}
        className={active.show ? style.btn : styleActive}
      >
        <span className={styleLine1}></span>
        <span className={styleLine2}></span>
        <span className={styleLine3}></span>
      </div>
      <ul className={active.show ? style.hide : style.show}>
        {pages.map((page, index) => (
          <div>
            <li key={index}>
              <Link to={page.route}>{page.nome}</Link>
            </li>
          </div>
        ))}
      </ul>
    </nav>
  );
}
