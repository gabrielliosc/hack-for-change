import Menu from "./menu";
import style from "./header.module.scss";
import logo from "../../assets/img/logo2.png";

export default function Header(){
    return (
    <div className={style.header}>
        <h1 className={style.item1}><img src={logo} alt="Logo com livro e controle de videogame"></img></h1>
        <span className={style.item2}><Menu /></span> 
    </div>
    )
}
