import style from './about.module.scss';
import imgAbout from '../../assets/img/img_sobre.jpg';
import { Link } from 'react-router-dom';

const classImg = `=${style.coluna} ${style.artistPicture}`

export default function About() {
    return (
        <div className={style.sobre}>
            <h2>Sobre a PEG</h2>
            <div className={style.artist}>
                <span className={style.coluna}>
                    <p>A Plataforma de Ensino Gameficado tem como objetivo tornar o estudo mais divertido e dinâmico. <Link to="/cadastro">Faça sua conta</Link> e comece a jogar junto com seus amigos! </p>
                    <p></p>
                </span>
                <img src={imgAbout} alt="" className={classImg}></img>              
            </div>  
        </div>
    )
}