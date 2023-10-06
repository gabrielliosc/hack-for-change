import { Link } from 'react-router-dom';
import Header from '../components/header';
import Footer from '../components/footer';
import About from '../components/about'

export default function Home() {
  return (
    <div>
        <Header />
        <About />
        <Footer />
    </div>
  );
};
