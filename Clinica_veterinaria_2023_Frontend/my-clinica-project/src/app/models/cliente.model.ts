import { Animal } from "./animal.model";

export class Cliente {
    iD_Cliente: number;
    nome: string;
    endereco: string | null;
    email: string;
    telefone: string | null;
    ID_Usuario: number;
    animais: Animal[];
}
