import { Grid } from "@mui/material";
import ItemCard from "./ItemCard";

export default function CatalogueView() {
  return (
    <Grid container xs={12} md={8} justifyContent="space-around" >
      <ItemCard />
      <ItemCard />
      <ItemCard />
      <ItemCard />
    </Grid>
  );
}