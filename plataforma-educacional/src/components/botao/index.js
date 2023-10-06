import style from "./botao.module.scss";
export default function Botao({ id, type, label }) {
  return (
    <div>
      <button className={style.button} id={id} type={type}>
        {label}
      </button>
    </div>
  );
}
