import UserComment from "./UserComment";
import CommentForm from "./CommentForm";
import { Grid, Stack } from "@mui/material";

export default function CommentBox() {
  return (
    <Grid item xs={12} md={4} >
      <Stack container spacing={3}>
        <CommentForm />
        <UserComment />
        <UserComment />
      </Stack>
    </Grid>
  );
}