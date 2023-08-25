import { Animal } from "./animal.model";

export interface Consulta {
  iD_Consulta: number;
  iD_Usuario: number;
  usuarioSistemaClinica: string | null; // Use the appropriate type or interface
  dataMarcacao: string;
  inicioConsulta: string;
  fimConsulta: string;
  descricao: string;
  iD_Veterinario: number;
  veterinario: string | null; // Use the appropriate type or interface
  iD_Animal: number;
  animal: Animal;
  status: number;
}
