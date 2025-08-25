import { useEffect, useState } from "react";
import { Formik, Form, Field, FieldArray, ErrorMessage } from "formik";
import * as Yup from "yup";
import {
  addProperty,
  getCountries,
  getStates,
} from "../services/property/PropertyServices";
import { toast } from "react-toastify";
import { PropertyTypes } from "../interfaces/IPropertyTypes";

interface Space {
  id?: string;
  type: string;
  size: number | "";
  description: string;
}

interface AddPropertiesProps {
  show: boolean;
  onClose: () => void;
  onAdd: (newProperty: any) => void;
}

const validationSchema = Yup.object({
  type: Yup.string().required("Property type is required"),
  price: Yup.number()
    .typeError("Price must be a number")
    .positive("Price must be greater than 0")
    .required("Price is required"),
  address: Yup.string()
    .trim()
    .matches(/^(?!\s*$).+$/, "Address cannot be empty or spaces only")
    .required("Address is required"),
  city: Yup.string().required("City is required"),
  postalCode: Yup.number()
    .typeError("Postal Code must be a number")
    .positive("Postal Code must be greater than 0")
    .required("Postal Code is required"),
  countryId: Yup.string().required("Country is required"),
  stateId: Yup.string().required("State is required"),

  description: Yup.string()
    .matches(/^(?!\s).*/, "Description cannot start with a space")
    .max(200, "Description cannot exceed 200 characters")
    .nullable(),

  spaces: Yup.array().of(
    Yup.object({
      type: Yup.string().required("Space type is required"),
      size: Yup.number()
        .typeError("Size must be a number")
        .positive("Size must be greater than 0")
        .required("Size is required"),
      description: Yup.string()
        .matches(/^(?!\s).*/, "Description cannot start with a space")
        .max(200, "Description cannot exceed 200 characters")
        .nullable(),
    })
  ),
});

const AddProperties: React.FC<AddPropertiesProps> = ({
  show,
  onClose,
  onAdd,
}) => {
  const [countries, setCountries] = useState<any[]>([]);
  const [states, setStates] = useState<any[]>([]);
  const [loading, setLoading] = useState(false);

  const spacesTypes = ["Living Room", "Garden", "Bedroom", "Garage", "Kitchen"];

  useEffect(() => {
    const loadInitialData = async () => {
      if (!show) return;
      try {
        const countriesRes = await getCountries();
        setCountries(countriesRes.data);
      } catch (err) {
        console.error("Error loading initial data:", err);
      }
    };

    loadInitialData();
  }, [show]);

  if (!show) return null;

  return (
    <>
      <div
        className="position-fixed top-50 start-50 translate-middle bg-white p-3 rounded-3 shadow-lg"
        style={{
          zIndex: 1050,
          width: "70%",
          maxWidth: "600px",
          maxHeight: "85vh",
          marginTop: "20px",
          overflowY: "auto",
        }}
      >
        <Formik
          initialValues={{
            type: "",
            price: "",
            description: "",
            address: "",
            city: "",
            postalCode: "",
            stateId: "",
            countryId: "",
            spaces: [] as Space[],
          }}
          validationSchema={validationSchema}
          onSubmit={async (values, { resetForm }) => {
            try {
              setLoading(true);
              const sanitizedValues = {
                ...values,
                price: Number(values.price),
                postalCode: String(values.postalCode),
              };

              const res = await addProperty(sanitizedValues);
              onAdd?.(res.data ?? sanitizedValues);
              toast.success("Property added successfully");
              resetForm();
              onClose();
            } catch (err) {
              console.error("Error creating property:", err);
              toast.error("Failed to add property");
            } finally {
              setLoading(false);
            }
          }}
        >
          {({ values }) => (
            <Form className="row g-2">
              <div className="d-flex justify-content-between align-items-center mb-3 border-bottom pb-1">
                <h5 className="fw-bold text-primary mb-0">
                  <i className="bi bi-house-add me-2"></i> Add Property
                </h5>
              </div>

              {/* Property Type */}
              <div className="col-md-6">
                <label className="form-label small">Property Type</label>
                <Field
                  name="type"
                  as="select"
                  className="form-select form-select-sm"
                >
                  <option value="">Select Type</option>
                  {PropertyTypes.map((type) => (
                    <option key={type} value={type}>
                      {type}
                    </option>
                  ))}
                </Field>
                <ErrorMessage
                  name="type"
                  component="div"
                  className="text-danger small"
                />
              </div>

              {/* Price */}
              <div className="col-md-6">
                <label className="form-label small">Price</label>
                <Field
                  name="price"
                  type="number"
                  className="form-control form-control-sm"
                />
                <ErrorMessage
                  name="price"
                  component="div"
                  className="text-danger small"
                />
              </div>

              {/* Address */}
              <div className="col-md-12">
                <label className="form-label small">Address</label>
                <Field
                  name="address"
                  type="text"
                  className="form-control form-control-sm"
                />
                <ErrorMessage
                  name="address"
                  component="div"
                  className="text-danger small"
                />
              </div>

              {/* Description */}
              <div className="col-md-12">
                <label className="form-label small">Description</label>
                <Field
                  as="textarea"
                  name="description"
                  rows={2}
                  className="form-control form-control-sm"
                />
                <ErrorMessage
                  name="description"
                  component="div"
                  className="text-danger small"
                />
              </div>

              {/* City */}
              <div className="col-md-6">
                <label className="form-label small">City</label>
                <Field
                  name="city"
                  type="text"
                  className="form-control form-control-sm"
                />
                <ErrorMessage
                  name="city"
                  component="div"
                  className="text-danger small"
                />
              </div>

              <div className="col-md-6">
                <label className="form-label small">Postal Code</label>
                <Field
                  name="postalCode"
                  type="number"
                  className="form-control form-control-sm"
                />
                <ErrorMessage
                  name="postalCode"
                  component="div"
                  className="text-danger small"
                />
              </div>

              {/* Country */}
              <div className="col-md-6">
                <label className="form-label small">Country</label>
                <Field name="countryId">
                  {({ field, form }: any) => (
                    <select
                      {...field}
                      className="form-select form-select-sm"
                      onChange={async (e) => {
                        const countryId = e.target.value;
                        form.setFieldValue("countryId", countryId);

                        if (countryId) {
                          const res = await getStates(countryId);
                          setStates(res.data);
                        } else {
                          setStates([]);
                        }
                      }}
                    >
                      <option value="">Select Country</option>
                      {countries.map((country) => (
                        <option key={country.id} value={country.id}>
                          {country.name}
                        </option>
                      ))}
                    </select>
                  )}
                </Field>
                <ErrorMessage
                  name="countryId"
                  component="div"
                  className="text-danger small"
                />
              </div>

              {/* State */}
              <div className="col-md-6">
                <label className="form-label small">State</label>
                <Field
                  name="stateId"
                  as="select"
                  className="form-select form-select-sm"
                >
                  <option value="">Select State</option>
                  {states.map((state) => (
                    <option key={state.id} value={state.id}>
                      {state.name}
                    </option>
                  ))}
                </Field>
                <ErrorMessage
                  name="stateId"
                  component="div"
                  className="text-danger small"
                />
              </div>

              {/* Spaces */}
              <FieldArray name="spaces">
                {({ push, remove }) => (
                  <div className="col-12">
                    <label className="form-label small">Spaces</label>
                    {values.spaces.map((_, index) => (
                      <div key={index} className="border rounded p-2 mb-2">
                        <div className="row g-2 align-items-start">
                          <div className="col-md-4">
                            <Field
                              as="select"
                              name={`spaces.${index}.type`}
                              className="form-select form-select-sm"
                            >
                              <option value="">Type</option>
                              {spacesTypes.map((type) => (
                                <option key={type} value={type}>
                                  {type}
                                </option>
                              ))}
                            </Field>
                            <ErrorMessage
                              name={`spaces.${index}.type`}
                              component="div"
                              className="text-danger small"
                            />
                          </div>
                          <div className="col-md-3">
                            <Field
                              name={`spaces.${index}.size`}
                              type="number"
                              placeholder="Size"
                              className="form-control form-control-sm"
                            />
                            <ErrorMessage
                              name={`spaces.${index}.size`}
                              component="div"
                              className="text-danger small"
                            />
                          </div>
                          <div className="col-md-4">
                            <Field
                              name={`spaces.${index}.description`}
                              placeholder="Description"
                              className="form-control form-control-sm"
                            />
                            <ErrorMessage
                              name={`spaces.${index}.description`}
                              component="div"
                              className="text-danger small"
                            />
                          </div>
                          <div className="col-md-1 d-flex align-items-start">
                            <button
                              type="button"
                              className="btn btn-outline-danger btn-sm"
                              onClick={() => remove(index)}
                            >
                              <i className="bi bi-trash"></i>
                            </button>
                          </div>
                        </div>
                      </div>
                    ))}

                    <button
                      type="button"
                      className="btn btn-outline-primary btn-sm mt-2"
                      onClick={() =>
                        push({ type: "", size: "", description: "" })
                      }
                    >
                      <i className="bi bi-plus-circle"></i> Add Space
                    </button>
                  </div>
                )}
              </FieldArray>

              {/* Submit + Cancel */}
              <div className="col-12 d-flex justify-content-end mt-3">
                <button
                  type="submit"
                  className="btn btn-success btn-sm px-3 me-2"
                  disabled={loading}
                >
                  {loading ? (
                    <>
                      <span
                        className="spinner-border spinner-border-sm me-1"
                        role="status"
                        aria-hidden="true"
                      ></span>
                      Submitting...
                    </>
                  ) : (
                    <>
                      <i className="bi bi-check-circle me-1"></i> Submit
                    </>
                  )}
                </button>
                <button
                  type="button"
                  className="btn btn-outline-danger btn-sm px-3"
                  onClick={onClose}
                  disabled={loading}
                >
                  <i className="bi bi-x-circle me-1"></i> Cancel
                </button>
              </div>
            </Form>
          )}
        </Formik>
      </div>
      <div
        onClick={onClose}
        className="position-fixed top-0 start-0 w-100 h-100 bg-dark bg-opacity-50"
        style={{ zIndex: 1040 }}
      />
    </>
  );
};

export default AddProperties;
