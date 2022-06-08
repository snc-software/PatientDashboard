import { AppBar, Toolbar, Typography } from "@mui/material";

export default function Header() {
  return (
    <AppBar position="fixed" elevation={0} color="primary">
      <Toolbar>
        <Typography variant="h6" sx={{ flexGrow: 1 }}>
          Patient Dashboard
        </Typography>
      </Toolbar>
    </AppBar>
  );
}