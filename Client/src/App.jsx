import { CssBaseline, Grid, Stack } from "@mui/material"

import Navbar from "./components/Navbar";


export default function App() {
  return (
    <>
      <CssBaseline>
        <Stack>
          <Navbar />
          <Grid container spacing={3} padding={3} justifyContent={"center"}>
          </Grid>
        </Stack>
      </CssBaseline>
    </>
  );
}
