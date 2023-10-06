import ReactDOM from "react-dom/client";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import style from "./App.module.scss";

import Home from "./pages/Home";
import Cadastro from "./pages/Cadastro";
import Login from "./pages/Login";
import TesteHabilidade from "./pages/TesteHabilidade";
import Perfil from "./pages/Perfil";
import Mapa from "./pages/Mapa";
import NoPage from "./pages/NoPage";
import Fase from "./pages/Fase";

export default function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" Component={Home} exact />
        <Route path="cadastro" Component={Cadastro} />
        <Route path="login" Component={Login} />
        <Route path="teste-habilidade" Component={TesteHabilidade} />
        <Route path="perfil" Component={Perfil} /> 
        <Route path="mapa" Component={Mapa} />  
        <Route path="fase/:name" Component={Fase} />
        <Route path="*" Component={NoPage} />
      </Routes>
    </BrowserRouter>
  );
}
