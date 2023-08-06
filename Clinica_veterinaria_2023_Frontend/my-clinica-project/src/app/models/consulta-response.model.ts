import { Consulta } from "./consulta.model";

export interface ConsultaResponse {
  total: number;
  consultas: Consulta[];
}
