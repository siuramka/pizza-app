import { useEffect, useState } from "react";
import { getPizzaOrders } from "../../services/PizzaOrderService";
import { IPizzaOrderWithToppings } from "./../../interfaces/IPizzaOrderWithToppings";
import {
  TableContainer,
  Paper,
  Table,
  TableHead,
  TableRow,
  TableCell,
  TableBody,
  Typography,
  Alert,
  AlertTitle,
} from "@mui/material";
const OrdersPage = () => {
  const [orders, setOrders] = useState<IPizzaOrderWithToppings[]>();

  useEffect(() => {
    getPizzaOrders().then((ordersData) => setOrders(ordersData));
  }, []);

  return (
    <div>
      {orders && orders.length > 0 ? (
        <div>
          <Typography variant="h6" component="div" sx={{ mb: 2 }}>
            Your orders
          </Typography>
          <TableContainer component={Paper}>
            <Table>
              <TableHead>
                <TableRow>
                  <TableCell align="left">Order #ID</TableCell>
                  <TableCell align="left">Pizza size</TableCell>
                  <TableCell align="left">Toppings</TableCell>
                  <TableCell align="left">Price $ (dollars)</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {orders &&
                  orders.map((order) => (
                    <TableRow
                      key={order.id}
                      sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
                    >
                      <TableCell align="left">{order.id}</TableCell>
                      <TableCell align="left">{order.size}</TableCell>
                      <TableCell align="left">
                        {order.toppings.toString()}
                      </TableCell>
                      <TableCell align="left">${order.totalCost}</TableCell>
                    </TableRow>
                  ))}
              </TableBody>
            </Table>
          </TableContainer>
        </div>
      ) : (
        <div>
          <Alert severity="info">
            <AlertTitle>No 🍕 orders yet!</AlertTitle>
            Please go order! 🍕🍕🍕🍕🍕🍕
          </Alert>
        </div>
      )}
    </div>
  );
};

export default OrdersPage;
