import {
  Card,
  CardHeader,
  CardMedia,
  CardContent,
  CardActions,
  Avatar,
  IconButton,
  Typography
} from '@mui/material';
import CartIcon  from '@mui/icons-material/ShoppingCart';
import ShareIcon from '@mui/icons-material/Share';

import { red } from '@mui/material/colors';

import testImage from "../assets/ps5.jpg";


function ItemCard() {
  return (
    <Card sx={{ maxWidth: 345 }}>
      <CardHeader
        avatar={
          <Avatar sx={{ bgcolor: red[500] }} aria-label="recipe">
            R
          </Avatar>
        }
        title="The Playstation 5"
        subheader="June 7, 2023"
      />

      <CardMedia component="img" height="194" image={testImage} alt="ps-5" />

      <CardContent>
        <Typography variant="body2" color="text.secondary">
          Praesent non tortor varius, pretium magna eu, bibendum nunc. Nullam
          efficitur justo nulla, eu efficitur massa convallis eu. Donec id
          aliquam urna. Mauris porttitor augue eget nisi cursus sagittis.
          Suspendisse porttitor velit tortor, aliquam fringilla purus blandit
          sit amet.
        </Typography>
      </CardContent>

      <CardActions disableSpacing>
        <IconButton aria-label="add to cart">
          <CartIcon />
        </IconButton>
        <IconButton aria-label="share">
          <ShareIcon />
        </IconButton>

      </CardActions>
    </Card>
  );
}

export default ItemCard;