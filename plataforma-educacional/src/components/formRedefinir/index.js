import Input from "../input";
import style from "./redefinir.module.scss";
import Botao from "../botao";
import Retorno from "../retorno";

export default function FormRedefinir() {
  return (
    <>
      <div className={style.container}>
        <div className={style.form}>
          <Retorno pagina="/" />
          <div className={style.cadastro}>
            <h1>Redefinir senha</h1>
            <Input
              label="Digite sua nova senha: "
              type="password"
              id="redefinir"
              placeholder="Insira uma nova senha"
            />
            <Input
              label="Confirme a senha: "
              type="password"
              id="redefinir"
              placeholder="Confirmar senha"
            />
          </div>
          <Botao id="redefinir" label="Confirmar" type="submit" />
        </div>
      </div>
    </>
  );
}
