import api from "../api/api";
import { ITopping } from "../interfaces/ITopping";

export const getToppings = async () => {
  try {
    const response = await api.get<ITopping[]>("/toppings");
    if (response.status === 200) return response.data;

    return undefined;
  } catch {
    return undefined;
  }
};
