import { useParams } from "react-router-dom";

export default function Fase(){
    const { name } = useParams()

    return(
        <div>
            {name}
        </div>
    )
}