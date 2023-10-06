import { Link } from 'react-router-dom';
import Trilha from '../components/trilha';
import Header from '../components/header';
import Footer from '../components/footer';

export default function Mapa() {
  return (
    <div>
      <Header />
      <Trilha />
      <Footer />
    </div>
  );
};