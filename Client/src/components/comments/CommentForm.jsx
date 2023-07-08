import { Button, Card, TextareaAutosize } from "@mui/material";


export default function CommentForm() {
  return (
    <Card sx={{ paddingX: 2, paddingY: 2 }}>
      <TextareaAutosize style={{ width: "100%" }} minRows={3} placeholder="Write a comment" />
      <Button variant="contained" >Submit</Button>
    </Card>
  );
}