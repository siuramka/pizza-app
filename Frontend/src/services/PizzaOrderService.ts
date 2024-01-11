import api from "../api/api";
import { IPizzaOrder } from "../interfaces/IPizzaOrder";
import { IPizzaOrderCreate } from "../interfaces/IPizzaOrderCreate";
import { IPizzaOrderWithToppings } from "../interfaces/IPizzaOrderWithToppings";

export const getPizzaOrders = async () => {
  try {
    const response = await api.get<IPizzaOrderWithToppings[]>("/pizzas/orders");
    if (response.status === 200) return response.data;

    return undefined;
  } catch {
    return undefined;
  }
};

type PizzaOrderParams = {
  PizzaOrder: IPizzaOrderCreate;
};

export const createPizzaOrder = async ({ PizzaOrder }: PizzaOrderParams) => {
  try {
    const response = await api.post<IPizzaOrder>("/pizzas/orders", PizzaOrder);
    if (response.status == 201) return response.data;

    return undefined;
  } catch {
    return undefined;
  }
};
