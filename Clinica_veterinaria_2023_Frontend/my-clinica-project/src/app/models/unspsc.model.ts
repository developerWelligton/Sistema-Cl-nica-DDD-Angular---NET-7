export interface Unspsc {
  idUnspsc: number;
  codigoSfcm: string;
  iD_Usuario: number;
  usuario?: Usuario;
  idSegmento: number;
  segmento: Segmento;
  idFamilia: number;
  familia: Familia;
  idClasse: number;
  classe: Classe;
  idMercadoria: number;
  mercadoria: Mercadoria;
  descricaoSegmento?: string;
  descricaoFamilia?: string;
  descricaoClasse?: string;
  descricaoMercadoria?: string;
}

interface Usuario {
  // Adicione propriedades conforme necessário
}

interface Segmento {
  idSegmento: number;
  codigo: string;
  descricao: string;
  iD_Usuario: number;
  usuario?: Usuario;
}

interface Familia {
  idFamilia: number;
  codigo: string;
  descricao: string;
  iD_Usuario: number;
  usuario?: Usuario;
}

interface Classe {
  idClasse: number;
  codigo: string;
  descricao: string;
  iD_Usuario: number;
  usuario?: Usuario;
}

interface Mercadoria {
  idMercadoria: number;
  codigo: string;
  descricao: string;
  iD_Usuario: number;
  usuario?: Usuario;
}
