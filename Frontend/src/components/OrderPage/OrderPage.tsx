import {
  Alert,
  AlertTitle,
  Box,
  Chip,
  FormControl,
  IconButton,
  InputLabel,
  MenuItem,
  OutlinedInput,
  Paper,
  Select,
  SelectChangeEvent,
  Typography,
} from "@mui/material";
import LocalPizzaIcon from "@mui/icons-material/LocalPizza";
import { useEffect, useState } from "react";
import { getToppings } from "../../services/ToppingService";
import { ITopping } from "../../interfaces/ITopping";
import { IPizzaOrderCreate } from "../../interfaces/IPizzaOrderCreate";
import { IPizzaOrder } from "../../interfaces/IPizzaOrder";
import { createPizzaOrder } from "../../services/PizzaOrderService";
import LoadingButton from "@mui/lab/LoadingButton";

export const OrderPage = () => {
  const pizzaSizes: string[] = ["Large $12", "Medium $10", "Small $8"];

  const [toppings, setToppings] = useState<ITopping[]>();

  const [selectedSize, setSelectedSize] = useState<string>(pizzaSizes[0]);
  const [selectedToppings, setSelectedToppings] = useState<string[]>([]);

  const [order, setOrder] = useState<IPizzaOrder | undefined>(undefined);
  const [error, setError] = useState<boolean>(false);

  const [isLoading, setIsLoading] = useState<boolean>(false);

  const onOrderSubmit = async () => {
    setError(false);
    setOrder(undefined);
    setIsLoading(true);

    const pizzaOrder: IPizzaOrderCreate = {
      Size: selectedSize.split(" ")[0],
      Toppings: selectedToppings,
    };

    const createdOrder = await createPizzaOrder({
      PizzaOrder: pizzaOrder,
    });

    if (createdOrder) {
      setOrder(createdOrder);
    } else {
      setError(true);
    }

    setIsLoading(false);
  };

  const handleChange = (event: SelectChangeEvent<typeof selectedToppings>) => {
    const {
      target: { value },
    } = event;
    setSelectedToppings(typeof value === "string" ? value.split(",") : value);
  };

  const handleSizeChange = (size: string) => {
    setSelectedSize(size);
  };

  useEffect(() => {
    getToppings().then((toppingList) => {
      setToppings(toppingList);
    });
  }, []);

  return (
    <>
      <Typography variant="h6" component="div" sx={{ mb: 2 }}>
        Welcome, please select your Pizza!
      </Typography>
      <Paper sx={{ p: 2, height: "80vh" }}>
        <Box sx={{ display: "flex", flexDirection: "column" }}>
          <Box>
            <Typography variant="h6" component="div" sx={{ mb: 3 }}>
              Size
            </Typography>
          </Box>
          <Box
            sx={{ display: "flex", flexDirection: "row", alignItems: "end" }}
          >
            {pizzaSizes.map((pizzaSize, index) =>
              pizzaSize === selectedSize ? (
                <IconButton
                  color="primary"
                  sx={{ mr: 4 }}
                  onClick={() => handleSizeChange(pizzaSize)}
                >
                  <div>
                    <LocalPizzaIcon sx={{ fontSize: 100 / (index + 1.2) }} />
                    <div>{pizzaSize}</div>
                  </div>
                </IconButton>
              ) : (
                <IconButton
                  color="inherit"
                  sx={{ mr: 4 }}
                  onClick={() => handleSizeChange(pizzaSize)}
                >
                  <div>
                    <LocalPizzaIcon sx={{ fontSize: 100 / (index + 1.2) }} />
                    <div>{pizzaSize}</div>
                  </div>
                </IconButton>
              )
            )}
          </Box>
          <Box>
            <Typography variant="h6" component="div" sx={{ mb: 2, mt: 2 }}>
              Toppings
            </Typography>
          </Box>
          <Box>
            {toppings && (
              <FormControl sx={{ m: 1, width: 400 }}>
                <InputLabel>Toppings</InputLabel>
                <Select
                  multiple
                  value={selectedToppings}
                  onChange={handleChange}
                  input={
                    <OutlinedInput id="select-multiple-chip" label="Chip" />
                  }
                  renderValue={(selected) => (
                    <Box sx={{ display: "flex", flexWrap: "wrap", gap: 0.5 }}>
                      {selected.map((value) => (
                        <Chip color="primary" key={value} label={value} />
                      ))}
                    </Box>
                  )}
                >
                  {toppings.length > 0 &&
                    toppings.map((topping) => (
                      <MenuItem key={topping.id} value={topping.name}>
                        {topping.name} + $1
                      </MenuItem>
                    ))}
                </Select>
              </FormControl>
            )}
          </Box>
          <Box>
            <LoadingButton
              variant="contained"
              sx={{ mt: 2, mb: 2, ml: 1, p: 2, width: "400px" }}
              onClick={onOrderSubmit}
              loading={isLoading}
            >
              Create order
            </LoadingButton>
          </Box>
          <Box>
            {order && (
              <Alert severity="success">
                <AlertTitle>
                  Order with number #{order.id} was created!
                </AlertTitle>
                Your total cost will be: ${order.totalCost}
              </Alert>
            )}
            {error && (
              <Alert severity="error">
                <AlertTitle>Sorry!</AlertTitle>
                Something went wrong with your order, could not submit order!
              </Alert>
            )}
          </Box>
        </Box>
      </Paper>
    </>
  );
};

export default OrderPage;
