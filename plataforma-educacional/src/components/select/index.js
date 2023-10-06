import style from "./select.module.scss";

export default function Select({ label, options, id }) {
  return (
    <div className={style.select}>
      <label htmlFor={id}>{label}</label>
      <select id={id}>
        {options.map((item) => (
          <option value={item.value} className={style.option}>{item.label}</option>
        ))}
      </select>
      <br />
    </div>
  );
}