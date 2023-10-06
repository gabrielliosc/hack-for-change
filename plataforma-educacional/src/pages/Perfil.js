import { Link } from 'react-router-dom';
import Profile from '../components/perfil';
import Header from '../components/header';
import Footer from '../components/footer';

export default function Perfil() {
  return (
    <div>
      <Header />
      <Profile />
      <Footer />
    </div>
  );
};