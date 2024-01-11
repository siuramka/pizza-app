import AppBar from "@mui/material/AppBar";
import Toolbar from "@mui/material/Toolbar";
import LocalPizzaIcon from "@mui/icons-material/LocalPizza";
import Typography from "@mui/material/Typography";
import Button from "@mui/material/Button";
import { Box } from "@mui/material";
import { useNavigate } from "react-router-dom";

function PizzaAppBar() {
  const navigate = useNavigate();
  return (
    <AppBar>
      <Toolbar>
        <Box sx={{ mr: 4 }}>
          <LocalPizzaIcon />
        </Box>
        <Typography
          variant="h6"
          component="div"
          sx={{
            mr: 4,
            display: { xs: "none", sm: "none", md: "flex" },
            letterSpacing: ".2rem",
          }}
        >
          The best pizza order app in the universe
        </Typography>
        <Button color="inherit" onClick={() => navigate("/order")}>
          Order a 🍕izza
        </Button>
        <Button color="inherit" onClick={() => navigate("/orders")}>
          Orders
        </Button>
      </Toolbar>
    </AppBar>
  );
}
export default PizzaAppBar;
