import { Avatar, Card, CardContent, CardHeader, Typography, IconButton, Rating } from '@mui/material';
import { red } from '@mui/material/colors';
import MoreVertIcon from '@mui/icons-material/MoreVert';

export default function UserComment() {
  return (
    <Card>
      <CardHeader
        avatar={<Avatar sx={{ bgcolor: red[300] }} aria-label="recipe">R</Avatar>}
        action={<IconButton aria-label="settings"><Rating readOnly name="size-small" defaultValue={5} size="small" /> <MoreVertIcon /> </IconButton>}
        title="Randall Smith"
        subheader="September 16, 2023"
      />

      <CardContent>
        <Typography variant="body2" color="text.secondary">
          Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod
          tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim
          veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea
          commodo consequat. Duis aute irure dolor in reprehenderit in voluptate
          velit esse cillum dolore eu fugiat nulla pariatur.
        </Typography>
      </CardContent>
    </Card>
  );
}