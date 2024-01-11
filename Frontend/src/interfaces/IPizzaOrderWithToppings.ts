import { IPizzaOrder } from "./IPizzaOrder";

export interface IPizzaOrderWithToppings extends IPizzaOrder {
  toppings: string[];
}

export interface IPizzaOrdersWithToppingsList {
  PizzaOrders: IPizzaOrderWithToppings[];
}
