import { CssBaseline } from "@mui/material"
import Navbar from "./components/Navbar";
import ItemCard from "./components/ItemCard";

export default function App() {
  return (
    <>
      <CssBaseline>
        <Navbar />
        <ItemCard />
      </CssBaseline>
    </>
  );
}
