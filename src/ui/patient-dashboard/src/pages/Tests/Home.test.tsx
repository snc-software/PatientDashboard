import {
  fireEvent,
  render,
  screen,
  waitFor,
  waitForElementToBeRemoved,
} from "@testing-library/react";
import { GetClinicsResponse } from "../../models/GetClinicsResponse";
import Home from "../Home";
import { rest } from "msw";
import { setupServer } from "msw/node";
import { ErrorResponse } from "../../models/ErrorResponse";
import { GetPatientsForClinicResponse } from "../../models/GetPatientsForClinicResponse";

const apiUrl = process.env.REACT_APP_API_URL;
const clinicsUrl = `${apiUrl}/clinics`;
const clinic1PatientsUrl = `${apiUrl}/clinics/1/patients`;
const clinic2PatientsUrl = `${apiUrl}/clinics/2/patients`;

const clinicsResponse = rest.get<GetClinicsResponse>(
  clinicsUrl,
  (_, res, ctx) => {
    return res(
      ctx.json([
        {
          id: 1,
          name: "Clinic1",
        },
        {
          id: 2,
          name: "Clinic2",
        },
      ])
    );
  }
);

const clinic1PatientsResponse = rest.get<GetPatientsForClinicResponse>(
  clinic1PatientsUrl,
  (_, res, ctx) => {
    return res(
      ctx.json([
        {
          id: 1,
          firstName: "Daniel",
          secondName: "Craig",
        },
      ])
    );
  }
);

const clinic2PatientsResponse = rest.get<GetPatientsForClinicResponse>(
  clinic1PatientsUrl,
  (_, res, ctx) => {
    return res(
      ctx.json([
        {
          id: 2,
          firstName: "Sean",
          secondName: "Connery",
        },
      ])
    );
  }
);

const clinicsErrorResponse = rest.get<ErrorResponse>(
  clinicsUrl,
  (_req, res, ctx) => {
    return res(
      ctx.status(500),
      ctx.json({
        message: "Oops",
      })
    );
  }
);

const server = setupServer(
  clinicsResponse,
  clinic1PatientsResponse,
  clinic2PatientsResponse
);

beforeAll(() => server.listen());
afterEach(() => server.resetHandlers());
afterAll(() => server.close());

describe("HomeTests", () => {
  it("should render a drop down", () => {
    render(<Home />);
    var input = screen.getByTestId("clinic-selector");
    expect(input).toBeInTheDocument();
  });
});
