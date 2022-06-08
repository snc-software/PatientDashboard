import { Box, Backdrop, CircularProgress, styled, Typography } from "@mui/material";

const WhiteText = styled(Typography)({
    color: "#FFFFFF"
});


export default function Busy() {
  return (
    <>
      <Backdrop data-testid="backdrop" sx={{ color: "#fff" }} open={true}>
        <Box>
          <CircularProgress color="inherit" data-testid="spinner"/>
          <WhiteText>Loading...</WhiteText>
        </Box>
      </Backdrop>
    </>
  );
}
