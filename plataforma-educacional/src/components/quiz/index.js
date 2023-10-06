
import style from "./redefinir.module.scss";
import Retorno from "../retorno";
import Select from "../select";
export default function QuizForm() {
  return (
    <>
      <div>
      <Retorno pagina="/" />
        <div>
    <h1>Fase inicial:</h1>

    <div>
        <p>Pergunta</p>
        <Select
              label="Faz parte da Passos Magicos? "
              id="select"
              options={[
                { value: "alt1", label: "Alternativa 1" },
                { value: "alt2", label: "Alternativa 2" },
                { value: "alt3", label: "Alternativa 3" },
                { value: "alt4", label: "Alternativa 4" },
              ]}
            />
    </div>
        </div>
      </div>
    </>
  );
}
