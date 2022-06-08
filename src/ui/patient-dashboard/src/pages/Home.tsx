import {
  FormControl,
  InputLabel,
  Select,
  MenuItem,
  SelectChangeEvent,
  Container,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  styled,
  Typography,
  tableCellClasses
} from "@mui/material";
import { useEffect, useState } from "react";
import Busy from "../components/Busy";
import { Clinic } from "../models/contracts/Clinic";
import { Patient } from "../models/contracts/Patient";
import { ErrorResponse } from "../models/ErrorResponse";
import { GetClinicsResponse } from "../models/GetClinicsResponse";
import { GetPatientsForClinicResponse } from "../models/GetPatientsForClinicResponse";

var ErrorText = styled(Typography)({
  color: "#721C23"
});

const StyledTableCell = styled(TableCell)(({ theme }) => ({
  [`&.${tableCellClasses.head}`]: {
    backgroundColor: theme.palette.common.black,
    color: theme.palette.common.white,
  },
  [`&.${tableCellClasses.body}`]: {
    fontSize: 14,
  },
}));

const StyledTableRow = styled(TableRow)(({ theme }) => ({
  '&:nth-of-type(odd)': {
    backgroundColor: theme.palette.action.hover,
  },
  // hide last border
  '&:last-child td, &:last-child th': {
    border: 0,
  },
}));


function Home() {
  const [clinics, setClinics] = useState<Clinic[]>([]);
  const [patients, setPatients] = useState<Patient[]>([]);
  const [selectedClinic, setSelectedClinic] = useState<string>("");
  const [age, setAge] = useState<string>("");

  const [isBusy, setIsBusy] = useState<boolean>(false);
  const [errorResponse, setErrorResponse] = useState<string | null>(null);

  useEffect(() => {
    setIsBusy(true);
    const apiUrl = process.env.REACT_APP_API_URL;
    setTimeout(() => {
      fetch(`${apiUrl}/clinics`)
        .then((res) => {
          if (!res.ok) {
            return res.text().then((text) => {
              let parsedError: ErrorResponse = JSON.parse(text);
              throw new Error(parsedError.message);
            });
          }
          return res.json();
        })
        .then((data: GetClinicsResponse) => {
          setClinics(data.clinics);
          setIsBusy(false);
          setErrorResponse(null);
        })
        .catch((err) => {
          setErrorResponse(err.message);
          setIsBusy(false);
        });
    }, 1000);
  }, []);

  const onSelectedClinicChange = (e: SelectChangeEvent<string>) => {
    setSelectedClinic(e.target.value);
    let clinic = clinics.find((x) => x.name == e.target.value);
    setIsBusy(true);
    const apiUrl = process.env.REACT_APP_API_URL;
    setTimeout(() => {
      fetch(`${apiUrl}/clinics/${clinic?.id}/patients`)
        .then((res) => {
          if (!res.ok) {
            return res.text().then((text) => {
              let parsedError: ErrorResponse = JSON.parse(text);
              throw new Error(parsedError.message);
            });
          }
          return res.json();
        })
        .then((data: GetPatientsForClinicResponse) => {
          setPatients(data.patients);
          setIsBusy(false);
          setErrorResponse(null);
        })
        .catch((err) => {
          setErrorResponse(err.message);
          setIsBusy(false);
        });
    }, 1000);
  };



  return (
    <>
      <Container>
        <FormControl fullWidth>
          <InputLabel id="clinic-select-label">Clinic</InputLabel>
          <Select
            labelId="clinic-select-label"
            onChange={onSelectedClinicChange}
            value={selectedClinic}
            label="Clinic"
            data-testid="clinic-selector"
          >
            {(clinics || []).map((clinic: Clinic, i) => {
              return (
                <MenuItem key={i} value={clinic.name} 
                data-testid={`clinic-${i}`}>
                  {clinic.name}
                </MenuItem>
              );
            })}
          </Select>
        </FormControl>

        {isBusy && <Busy data-testid="busyindicator" />}
        {errorResponse && (
          <ErrorText data-testid="errormessage">{errorResponse}</ErrorText>
        )}
        {patients && patients.length > 0 && (
          <TableContainer component={Paper}>
            <Table>
              <TableHead>
                <TableRow>
                  <StyledTableCell>Id</StyledTableCell>
                  <StyledTableCell align="right">First Name</StyledTableCell>
                  <StyledTableCell align="right">Last Name</StyledTableCell>
                  <StyledTableCell align="right">D.O.B</StyledTableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {patients.map((patient) => (
                  <StyledTableRow
                    key={patient.id}
                    sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
                  >
                    <StyledTableCell component="th" scope="row">
                      {patient.id}
                    </StyledTableCell>
                    <StyledTableCell align="right">{patient.firstName}</StyledTableCell>
                    <StyledTableCell align="right">{patient.lastName}</StyledTableCell>
                    <StyledTableCell align="right">{new Date(patient.dateOfBirth).toDateString()}</StyledTableCell>
                  </StyledTableRow>
                ))}
              </TableBody>
            </Table>
          </TableContainer>
        )}
      </Container>
    </>
  );
}

export default Home;
