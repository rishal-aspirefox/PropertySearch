import type { Space } from "./ISpace";

export interface Property {
  id: number;
  address: string;
  type: string;
  price: number;
  description?: string;
  spaces: Space [];
}