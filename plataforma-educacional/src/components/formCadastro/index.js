import { Link } from "react-router-dom";
import Input from "../input";
import style from "./form.module.scss";
import Select from "../select";
import Botao from "../botao";
import Retorno from "../retorno";

export default function FormCadastro() {
  return (
    <>
      <div className={style.container}>
        <div className={style.form}>
          <Retorno pagina="/" />
          <form className={style.cadastro}>
            <h1>Cadastro</h1>
            <Input
              label="Nome: "
              type="text"
              id="name"
              placeholder="Insira o seu nome completo"
            />
            <Input
              label="Idade: "
              type="text"
              id="age"
              placeholder="Insira a sua idade"
            />
            <Input
              label="Telefone: "
              type="tel"
              id="tel"
              placeholder="Insira o seu telefone"
            />
            <Input
              label="Email: "
              type="email"
              id="email"
              placeholder="Insira o seu email"
            />
            <Input
              label="Senha: "
              type="password"
              id="password"
              placeholder="Insira uma senha"
            />
            <Select
              label="Faz parte da Passos Magicos? "
              id="select"
              options={[
                { value: "sim", label: "Sim" },
                { value: "nao", label: "Não" },
              ]}
            />
            <Input
              label="Se sim, qual é seu nível de conhecimento? "
              type="text"
              id="level"
              placeholder="O seu nível de conhecimento"
            />
            <Input
              label="Se não, em que série você está? "
              type="text"
              id="grade"
              placeholder="Insira a sua série atual"
            />
            <Link to="/login">Já tenho cadastro</Link>
          </form>
          <Botao id="cadastrar" label="Confirmar cadastro" type="submit" />
        </div>
      </div>
    </>
  );
}
