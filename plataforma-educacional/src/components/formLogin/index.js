import Input from "../input";
import style from "./login.module.scss";
import { Link } from "react-router-dom";
import Botao from "../botao";
import Retorno from "../retorno";

export default function FormLogin() {
  return (
    <>
      <div className={style.container}>
        <div className={style.form}>
          <Retorno pagina="/" />
          <div className={style.cadastro}>
            <h1>Login</h1>
            <Input
              label="Email: "
              type="email"
              id="email"
              placeholder="Seu email"
            />
            <Input
              label="Senha: "
              type="password"
              id="password"
              placeholder="Sua senha"
            />
            <div className={style.logflex}>
              <Link to="/redefinir">Esqueci a senha</Link>
              <Link to="/cadastro">Não tenho cadastro</Link>
            </div>
          </div>

          <Botao id="logar" label="Fazer login" type="submit" />
        </div>
      </div>
    </>
  );
}
