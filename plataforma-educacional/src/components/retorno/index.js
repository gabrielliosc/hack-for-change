import { Link } from "react-router-dom";
import style from "./retorno.module.scss"
export default function Retorno(pagina) {
  return (
    <div>
      <button className={style.btn}>
        <Link to="/" className="text-link">
          Voltar
        </Link>
      </button>
    </div>
  );
}
