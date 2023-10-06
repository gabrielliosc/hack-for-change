import style from "./input.module.scss";

export default function Input({ label, type, id, placeholder }) {
  return (
    <div className={style.input}>
      <label htmlFor={id}>{label}</label>
      <input type={type} id={id} placeholder={placeholder} />
      <br />
    </div>
  );
}
